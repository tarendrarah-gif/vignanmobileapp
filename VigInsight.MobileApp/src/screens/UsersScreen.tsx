import { Picker } from '@react-native-picker/picker';
import React, { useEffect, useMemo, useState } from 'react';
import { Alert, Button, Modal, StyleSheet, Switch, Text, TextInput, View } from 'react-native';
import { ScreenContainer } from '../components/ScreenContainer';
import { useAuth } from '../context/AuthContext';
import {
  createUser,
  deleteUser,
  getAllOrganizations,
  getRoles,
  getUsers,
  updateUser
} from '../services/apiService';
import { OrganizationModel, RoleModel, UserModel } from '../types/models';

const emptyForm = {
  userId: 0,
  username: '',
  password: '',
  roleId: 0,
  organizationId: 0,
  isActive: true
};

export const UsersScreen = () => {
  const { session } = useAuth();
  const [users, setUsers] = useState<UserModel[]>([]);
  const [roles, setRoles] = useState<RoleModel[]>([]);
  const [organizations, setOrganizations] = useState<OrganizationModel[]>([]);
  const [showModal, setShowModal] = useState(false);
  const [form, setForm] = useState(emptyForm);

  const canWrite = useMemo(() => {
    const role = session?.roleName.toLowerCase() || '';
    return role === 'admin' || role === 'client';
  }, [session?.roleName]);

  const load = async () => {
    if (!session) return;

    const [userData, roleData, orgData] = await Promise.all([
      getUsers(session.userId, session.roleName),
      getRoles(),
      getAllOrganizations()
    ]);

    setUsers(userData);
    setRoles(roleData);
    setOrganizations(orgData);
  };

  useEffect(() => {
    load();
  }, [session?.userId]);

  const openAdd = () => {
    setForm(emptyForm);
    setShowModal(true);
  };

  const openEdit = (user: UserModel) => {
    setForm({
      userId: user.userId,
      username: user.username,
      password: '',
      roleId: user.roleId,
      organizationId: user.organizationId,
      isActive: user.isActive
    });
    setShowModal(true);
  };

  const save = async () => {
    if (!form.username || !form.roleId || !form.organizationId) {
      Alert.alert('Validation', 'Username, role, and organization are required.');
      return;
    }

    if (!form.userId && !form.password) {
      Alert.alert('Validation', 'Password is required for new user.');
      return;
    }

    try {
      const now = new Date().toISOString();
      if (form.userId) {
        await updateUser(form.userId, {
          userId: form.userId,
          username: form.username,
          roleId: form.roleId,
          organizationId: form.organizationId,
          isActive: form.isActive,
          modifiedBy: session?.username,
          modifiedOn: now
        } as UserModel);
      } else {
        await createUser({
          user: {
            username: form.username,
            password: form.password,
            roleId: form.roleId,
            organizationId: form.organizationId,
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

  const remove = async (user: UserModel) => {
    Alert.alert('Delete user', `Delete ${user.username}?`, [
      { text: 'Cancel', style: 'cancel' },
      {
        text: 'Delete',
        style: 'destructive',
        onPress: async () => {
          await deleteUser(user.userId);
          await load();
        }
      }
    ]);
  };

  return (
    <ScreenContainer>
      <Text style={styles.title}>Users</Text>
      {canWrite && <Button title="Add User" onPress={openAdd} />}

      {users.map((user) => (
        <View key={user.userId} style={styles.card}>
          <Text style={styles.name}>{user.username}</Text>
          <Text>Role: {user.roleName || user.roleId}</Text>
          <Text>Organization: {user.organizationName || user.organizationId}</Text>
          <Text>Status: {user.isActive ? 'Active' : 'Inactive'}</Text>
          {canWrite && (
            <View style={styles.row}>
              <Button title="Edit" onPress={() => openEdit(user)} />
              <Button title="Delete" color="#dc2626" onPress={() => remove(user)} />
            </View>
          )}
        </View>
      ))}

      <Modal visible={showModal} animationType="slide">
        <ScreenContainer>
          <Text style={styles.title}>{form.userId ? 'Edit User' : 'Add User'}</Text>
          <TextInput
            style={styles.input}
            placeholder="Username"
            value={form.username}
            onChangeText={(value) => setForm((s) => ({ ...s, username: value }))}
          />

          {!form.userId && (
            <TextInput
              style={styles.input}
              placeholder="Password"
              secureTextEntry
              value={form.password}
              onChangeText={(value) => setForm((s) => ({ ...s, password: value }))}
            />
          )}

          <Text>Role</Text>
          <Picker selectedValue={form.roleId} onValueChange={(value) => setForm((s) => ({ ...s, roleId: Number(value) }))}>
            <Picker.Item label="Select role" value={0} />
            {roles.map((role) => (
              <Picker.Item key={role.roleId} label={role.roleName} value={role.roleId} />
            ))}
          </Picker>

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
