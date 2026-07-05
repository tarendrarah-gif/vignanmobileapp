import React, { useEffect, useMemo, useState } from 'react';
import { Alert, Button, Modal, StyleSheet, Switch, Text, TextInput, View } from 'react-native';
import { ScreenContainer } from '../components/ScreenContainer';
import { useAuth } from '../context/AuthContext';
import {
  createOrganization,
  deleteOrganization,
  getOrganizations,
  updateOrganization
} from '../services/apiService';
import { OrganizationModel } from '../types/models';

const emptyForm = {
  organizationId: 0,
  organizationName: '',
  organizationDescription: '',
  isActive: true
};

export const OrganizationsScreen = () => {
  const { session } = useAuth();
  const [organizations, setOrganizations] = useState<OrganizationModel[]>([]);
  const [showModal, setShowModal] = useState(false);
  const [form, setForm] = useState(emptyForm);

  const canWrite = useMemo(() => {
    const role = session?.roleName.toLowerCase() || '';
    return role === 'admin';
  }, [session?.roleName]);

  const load = async () => {
    if (!session) return;
    const organizationData = await getOrganizations(session.userId, session.roleName);
    setOrganizations(organizationData);
  };

  useEffect(() => {
    load();
  }, [session?.userId]);

  const openAdd = () => {
    setForm(emptyForm);
    setShowModal(true);
  };

  const openEdit = (organization: OrganizationModel) => {
    setForm({
      organizationId: organization.organizationId,
      organizationName: organization.organizationName,
      organizationDescription: organization.organizationDescription || '',
      isActive: organization.isActive
    });
    setShowModal(true);
  };

  const save = async () => {
    if (!form.organizationName) {
      Alert.alert('Validation', 'Organization name is required.');
      return;
    }

    try {
      const now = new Date().toISOString();
      if (form.organizationId) {
        await updateOrganization(form.organizationId, {
          organizationId: form.organizationId,
          organizationName: form.organizationName,
          organizationDescription: form.organizationDescription,
          isActive: form.isActive,
          modifiedBy: session?.username,
          modifiedOn: now
        });
      } else {
        await createOrganization({
          organizationName: form.organizationName,
          organizationDescription: form.organizationDescription,
          isActive: form.isActive,
          createdBy: session?.username,
          createdOn: now
        });
      }

      setShowModal(false);
      await load();
    } catch (error) {
      Alert.alert('Save failed', error instanceof Error ? error.message : 'Unknown error');
    }
  };

  const remove = async (organization: OrganizationModel) => {
    Alert.alert('Delete organization', `Delete ${organization.organizationName}?`, [
      { text: 'Cancel', style: 'cancel' },
      {
        text: 'Delete',
        style: 'destructive',
        onPress: async () => {
          await deleteOrganization(organization.organizationId);
          await load();
        }
      }
    ]);
  };

  return (
    <ScreenContainer>
      <Text style={styles.title}>Organizations</Text>
      {canWrite && <Button title="Add Organization" onPress={openAdd} />}

      {organizations.map((organization) => (
        <View key={organization.organizationId} style={styles.card}>
          <Text style={styles.name}>{organization.organizationName}</Text>
          <Text>Description: {organization.organizationDescription || '-'}</Text>
          <Text>Status: {organization.isActive ? 'Active' : 'Inactive'}</Text>
          {canWrite && (
            <View style={styles.row}>
              <Button title="Edit" onPress={() => openEdit(organization)} />
              <Button title="Delete" color="#dc2626" onPress={() => remove(organization)} />
            </View>
          )}
        </View>
      ))}

      <Modal visible={showModal} animationType="slide">
        <ScreenContainer>
          <Text style={styles.title}>{form.organizationId ? 'Edit Organization' : 'Add Organization'}</Text>
          <TextInput
            style={styles.input}
            placeholder="Organization name"
            value={form.organizationName}
            onChangeText={(value) => setForm((s) => ({ ...s, organizationName: value }))}
          />
          <TextInput
            style={styles.input}
            placeholder="Description"
            value={form.organizationDescription}
            onChangeText={(value) => setForm((s) => ({ ...s, organizationDescription: value }))}
          />
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
