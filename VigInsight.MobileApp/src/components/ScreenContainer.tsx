import React, { PropsWithChildren } from 'react';
import { SafeAreaView, ScrollView, StyleSheet, View } from 'react-native';

export const ScreenContainer = ({ children }: PropsWithChildren) => (
  <SafeAreaView style={styles.safeArea}>
    <ScrollView contentContainerStyle={styles.content}>
      <View>{children}</View>
    </ScrollView>
  </SafeAreaView>
);

const styles = StyleSheet.create({
  safeArea: {
    flex: 1,
    backgroundColor: '#f3f4f6'
  },
  content: {
    padding: 16,
    gap: 12
  }
});
