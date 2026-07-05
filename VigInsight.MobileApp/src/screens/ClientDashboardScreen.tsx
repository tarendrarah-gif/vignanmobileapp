import React, { useEffect, useState } from 'react';
import { Pressable, StyleSheet, Text, View } from 'react-native';
import { ScreenContainer } from '../components/ScreenContainer';
import { useAuth } from '../context/AuthContext';
import { getMachinesByOrganization } from '../services/apiService';
import { MachineModel } from '../types/models';

export const ClientDashboardScreen = () => {
  const { session } = useAuth();
  const [machines, setMachines] = useState<MachineModel[]>([]);

  useEffect(() => {
    if (!session?.organizationId) return;

    (async () => {
      const data = await getMachinesByOrganization(session.organizationId);
      setMachines(data);
    })();
  }, [session?.organizationId]);

  return (
    <ScreenContainer>
      <Text style={styles.title}>Client Dashboard</Text>
      <Text style={styles.subtitle}>Organization: {session?.organizationName || '-'}</Text>

      {machines.map((machine) => (
        <Pressable key={machine.machineId} style={styles.card}>
          <Text style={styles.name}>{machine.machineName}</Text>
          <Text>Status: {machine.isActive ? 'Active' : 'Inactive'}</Text>
          <Text>Performance: {machine.performance || 'N/A'}</Text>
        </Pressable>
      ))}
    </ScreenContainer>
  );
};

const styles = StyleSheet.create({
  title: { fontSize: 24, fontWeight: '700' },
  subtitle: { color: '#4b5563' },
  card: {
    backgroundColor: '#ffffff',
    borderRadius: 10,
    padding: 14,
    gap: 4
  },
  name: {
    fontWeight: '700'
  }
});
