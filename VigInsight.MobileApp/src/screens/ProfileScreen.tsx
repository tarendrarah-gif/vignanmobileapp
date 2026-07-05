import React from 'react';
import { Button, StyleSheet, Text, View } from 'react-native';
import { ScreenContainer } from '../components/ScreenContainer';
import { useAuth } from '../context/AuthContext';

export const ProfileScreen = () => {
  const { session, signOut } = useAuth();

  return (
    <ScreenContainer>
      <Text style={styles.title}>Profile</Text>
      <View style={styles.card}>
        <Text>Username: {session?.username}</Text>
        <Text>Role: {session?.roleName}</Text>
        <Text>Organization: {session?.organizationName || '-'}</Text>
      </View>
      <Button title="Log Out" color="#dc2626" onPress={signOut} />
    </ScreenContainer>
  );
};

const styles = StyleSheet.create({
  title: { fontSize: 24, fontWeight: '700' },
  card: {
    backgroundColor: '#ffffff',
    borderRadius: 10,
    padding: 14,
    gap: 4
  }
});
