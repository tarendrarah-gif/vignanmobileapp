import { RouteProp, useRoute } from '@react-navigation/native';
import React, { useEffect, useState } from 'react';
import { ActivityIndicator, StyleSheet, Text, View } from 'react-native';
import { ScreenContainer } from '../components/ScreenContainer';
import { getPageData } from '../services/apiService';
import { RootStackParamList } from '../types/navigation';

export const PageDataScreen = () => {
  const route = useRoute<RouteProp<RootStackParamList, 'PageData'>>();
  const [data, setData] = useState<Record<string, unknown>>({});
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    (async () => {
      try {
        setLoading(true);
        const response = await getPageData(route.params.pageId);
        setData(response);
      } finally {
        setLoading(false);
      }
    })();
  }, [route.params.pageId]);

  return (
    <ScreenContainer>
      <Text style={styles.title}>Page {route.params.pageId} Data</Text>
      <Text style={styles.subtitle}>Machine ID: {route.params.machineId || '-'}</Text>

      {loading ? (
        <ActivityIndicator />
      ) : (
        Object.entries(data).map(([key, value]) => (
          <View key={key} style={styles.card}>
            <Text style={styles.key}>{key}</Text>
            <Text>{String(value)}</Text>
          </View>
        ))
      )}
    </ScreenContainer>
  );
};

const styles = StyleSheet.create({
  title: { fontSize: 24, fontWeight: '700' },
  subtitle: { color: '#4b5563' },
  card: {
    backgroundColor: '#ffffff',
    borderRadius: 10,
    padding: 12
  },
  key: {
    fontWeight: '700'
  }
});
