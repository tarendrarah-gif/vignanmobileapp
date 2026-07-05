import { Picker } from '@react-native-picker/picker';
import React, { useEffect, useMemo, useState } from 'react';
import { Alert, Button, Modal, StyleSheet, Switch, Text, TextInput, View } from 'react-native';
import { ScreenContainer } from '../components/ScreenContainer';
import { useAuth } from '../context/AuthContext';
import {
  createMachine,
  deleteMachine,
  getAllOrganizations,
  getMachines,
  updateMachine
} from '../services/apiService';
import { MachineModel, OrganizationModel } from '../types/models';

const emptyForm = {
  machineId: 0,
  machineName: '',
  machineDescription: '',
  organizationId: 0,
  isActive: true
};

export const MachinesScreen = () => {
  const { session } = useAuth();
  const [machines, setMachines] = useState<MachineModel[]>([]);
  const [organizations, setOrganizations] = useState<OrganizationModel[]>([]);
  const [showModal, setShowModal] = useState(false);
  const [form, setForm] = useState(emptyForm);

  const canWrite = useMemo(() => {
    const role = session?.roleName.toLowerCase() || '';
    return role === 'admin' || role === 'client';
  }, [session?.roleName]);

  const load = async () => {
    if (!session) return;

    const [machineData, organizationData] = await Promise.all([
      getMachines(session.userId, session.roleName),
      getAllOrganizations()
    ]);

    setMachines(machineData);
    setOrganizations(organizationData);
  };

  useEffect(() => {
    load();
  }, [session?.userId]);

  const openAdd = () => {
    setForm(emptyForm);
    setShowModal(true);
  };

  const openEdit = (machine: MachineModel) => {
    setForm({
      machineId: machine.machineId,
      machineName: machine.machineName,
      machineDescription: machine.machineDescription || '',
      organizationId: machine.organizationId,
      isActive: machine.isActive
    });
    setShowModal(true);
  };

  const save = async () => {
    if (!form.machineName || !form.organizationId) {
      Alert.alert('Validation', 'Machine name and organization are required.');
      return;
    }

    try {
      const now = new Date().toISOString();
      if (form.machineId) {
        await updateMachine(form.machineId, {
          machine: {
            machineId: form.machineId,
            machineName: form.machineName,
            machineDescription: form.machineDescription,
            organizationId: form.organizationId,
            isActive: form.isActive,
            modifiedBy: session?.username,
            modifiedOn: now
          } as MachineModel,
          organizationId: form.organizationId
        });
      } else {
        await createMachine({
          machine: {
            machineName: form.machineName,
            machineDescription: form.machineDescription,
            isActive: form.isActive,
            createdBy: session?.username,
            createdOn: now
          },
          organizationId: form.organizationId
        });
      }

      setShowModal(false);
      await load();
    } catch (error) {
      Alert.alert('Save failed', error instanceof Error ? error.message : 'Unknown error');
    }
  };

  const remove = async (machine: MachineModel) => {
    Alert.alert('Delete machine', `Delete ${machine.machineName}?`, [
      { text: 'Cancel', style: 'cancel' },
      {
        text: 'Delete',
        style: 'destructive',
        onPress: async () => {
          await deleteMachine(machine.machineId);
          await load();
        }
      }
    ]);
  };

  return (
    <ScreenContainer>
      <Text style={styles.title}>Machines</Text>
      {canWrite && <Button title="Add Machine" onPress={openAdd} />}

      {machines.map((machine) => (
        <View key={machine.machineId} style={styles.card}>
          <Text style={styles.name}>{machine.machineName}</Text>
          <Text>Description: {machine.machineDescription || '-'}</Text>
          <Text>Organization: {machine.organizationName || machine.organizationId}</Text>
          <Text>Status: {machine.isActive ? 'Active' : 'Inactive'}</Text>
          {canWrite && (
            <View style={styles.row}>
              <Button title="Edit" onPress={() => openEdit(machine)} />
              <Button title="Delete" color="#dc2626" onPress={() => remove(machine)} />
            </View>
          )}
        </View>
      ))}

      <Modal visible={showModal} animationType="slide">
        <ScreenContainer>
          <Text style={styles.title}>{form.machineId ? 'Edit Machine' : 'Add Machine'}</Text>
          <TextInput
            style={styles.input}
            placeholder="Machine name"
            value={form.machineName}
            onChangeText={(value) => setForm((s) => ({ ...s, machineName: value }))}
          />
          <TextInput
            style={styles.input}
            placeholder="Description"
            value={form.machineDescription}
            onChangeText={(value) => setForm((s) => ({ ...s, machineDescription: value }))}
          />

          <Text>Organization</Text>
          <Picker
            selectedValue={form.organizationId}
            onValueChange={(value) => setForm((s) => ({ ...s, organizationId: Number(value) }))}
          >
            <Picker.Item label="Select organization" value={0} />
            {organizations.map((organization) => (
              <Picker.Item
                key={organization.organizationId}
                label={organization.organizationName}
                value={organization.organizationId}
              />
            ))}
          </Picker>

          <View style={styles.switchRow}>
            <Text>Active</Text>
            <Switch value={form.isActive} onValueChange={(value) => setForm((s) => ({ ...s, isActive: value }))} />
          </View>

          <View style={styles.row}>
            <Button title="Cancel" onPress={() => setShowModal(false)} />
            <Button title="Save" onPress={save} />
          </View>
        </ScreenContainer>
      </Modal>
    </ScreenContainer>
  );
};

const styles = StyleSheet.create({
  title: { fontSize: 24, fontWeight: '700' },
  card: {
    backgroundColor: '#ffffff',
    borderRadius: 10,
    padding: 12,
    gap: 4
  },
  name: { fontWeight: '700' },
  row: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    marginTop: 8
  },
  input: {
    borderWidth: 1,
    borderColor: '#d1d5db',
    borderRadius: 8,
    paddingHorizontal: 12,
    paddingVertical: 10
  },
  switchRow: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    alignItems: 'center'
  }
});
