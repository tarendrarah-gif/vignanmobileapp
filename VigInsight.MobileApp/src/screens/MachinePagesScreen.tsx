import { NativeStackNavigationProp } from '@react-navigation/native-stack';
import { useNavigation } from '@react-navigation/native';
import React, { useEffect, useState } from 'react';
import { Button, StyleSheet, Text, View } from 'react-native';
import { Picker } from '@react-native-picker/picker';
import { ScreenContainer } from '../components/ScreenContainer';
import { useAuth } from '../context/AuthContext';
import { getMachinesByOrganization } from '../services/apiService';
import { MachineModel } from '../types/models';
import { RootStackParamList } from '../types/navigation';

const pageIds = [2, 3, 5, 7, 10, 11, 14, 15, 18, 20, 21, 26, 29, 32, 34, 44, 53];

export const MachinePagesScreen = () => {
  const navigation = useNavigation<NativeStackNavigationProp<RootStackParamList>>();
  const { session } = useAuth();
  const [machines, setMachines] = useState<MachineModel[]>([]);
  const [machineId, setMachineId] = useState(0);

  useEffect(() => {
    if (!session?.organizationId) return;

    (async () => {
      const data = await getMachinesByOrganization(session.organizationId);
      setMachines(data);
      if (data.length > 0) {
        setMachineId(data[0].machineId);
      }
    })();
  }, [session?.organizationId]);

  return (
    <ScreenContainer>
      <Text style={styles.title}>Machine Overview Pages</Text>

      <Text>Machine</Text>
      <Picker selectedValue={machineId} onValueChange={(value) => setMachineId(Number(value))}>
        {machines.map((machine) => (
          <Picker.Item key={machine.machineId} label={machine.machineName} value={machine.machineId} />
        ))}
      </Picker>

      <View style={styles.list}>
        {pageIds.map((pageId) => (
          <Button
            key={pageId}
            title={`Open Page ${pageId}`}
            onPress={() => navigation.navigate('PageData', { pageId, machineId })}
          />
        ))}
      </View>
    </ScreenContainer>
  );
};

const styles = StyleSheet.create({
  title: { fontSize: 24, fontWeight: '700' },
  list: { gap: 10 }
});
