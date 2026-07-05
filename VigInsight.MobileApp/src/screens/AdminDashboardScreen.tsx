import React, { useEffect, useState } from 'react';
import { StyleSheet, Text, View } from 'react-native';
import { ScreenContainer } from '../components/ScreenContainer';
import { useAuth } from '../context/AuthContext';
import { getMachines, getOrganizations, getUsers } from '../services/apiService';

export const AdminDashboardScreen = () => {
  const { session } = useAuth();
  const [counts, setCounts] = useState({ users: 0, machines: 0, organizations: 0 });

  useEffect(() => {
    if (!session) return;

    (async () => {
      const role = session.roleName || 'Admin';
      const [users, machines, organizations] = await Promise.all([
        getUsers(session.userId, role),
        getMachines(session.userId, role),
        getOrganizations(session.userId, role)
      ]);

      setCounts({ users: users.length, machines: machines.length, organizations: organizations.length });
    })();
  }, [session]);

  return (
    <ScreenContainer>
      <Text style={styles.title}>Admin Dashboard</Text>
      <Text style={styles.subtitle}>Welcome {session?.username}</Text>

      <View style={styles.card}><Text>Users: {counts.users}</Text></View>
      <View style={styles.card}><Text>Machines: {counts.machines}</Text></View>
      <View style={styles.card}><Text>Organizations: {counts.organizations}</Text></View>
    </ScreenContainer>
  );
};

const styles = StyleSheet.create({
  title: { fontSize: 24, fontWeight: '700' },
  subtitle: { color: '#4b5563' },
  card: {
    backgroundColor: '#ffffff',
    borderRadius: 10,
    padding: 14
  }
});
