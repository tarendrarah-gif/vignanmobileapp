import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';
import { createNativeStackNavigator } from '@react-navigation/native-stack';
import React from 'react';
import { ActivityIndicator, View } from 'react-native';
import { useAuth } from '../context/AuthContext';
import { AdminDashboardScreen } from '../screens/AdminDashboardScreen';
import { ClientDashboardScreen } from '../screens/ClientDashboardScreen';
import { LoginScreen } from '../screens/LoginScreen';
import { MachinePagesScreen } from '../screens/MachinePagesScreen';
import { MachinesScreen } from '../screens/MachinesScreen';
import { OrganizationsScreen } from '../screens/OrganizationsScreen';
import { PageDataScreen } from '../screens/PageDataScreen';
import { ProfileScreen } from '../screens/ProfileScreen';
import { UsersScreen } from '../screens/UsersScreen';
import { RootStackParamList } from '../types/navigation';

const Stack = createNativeStackNavigator<RootStackParamList>();
const Tab = createBottomTabNavigator();

const MainTabs = () => {
  const { session } = useAuth();
  const role = session?.roleName.toLowerCase() || 'user';

  return (
    <Tab.Navigator>
      <Tab.Screen
        name="Dashboard"
        component={role === 'admin' ? AdminDashboardScreen : ClientDashboardScreen}
      />
      <Tab.Screen name="Users" component={UsersScreen} />
      <Tab.Screen name="Machines" component={MachinesScreen} />
      {role === 'admin' && <Tab.Screen name="Organizations" component={OrganizationsScreen} />}
      <Tab.Screen name="Machine Pages" component={MachinePagesScreen} />
      <Tab.Screen name="Profile" component={ProfileScreen} />
    </Tab.Navigator>
  );
};

export const AppNavigator = () => {
  const { session, isLoading } = useAuth();

  if (isLoading) {
    return (
      <View style={{ flex: 1, justifyContent: 'center', alignItems: 'center' }}>
        <ActivityIndicator />
      </View>
    );
  }

  if (!session) {
    return <LoginScreen />;
  }

  return (
    <Stack.Navigator>
      <Stack.Screen name="MainTabs" component={MainTabs} options={{ headerShown: false }} />
      <Stack.Screen name="PageData" component={PageDataScreen} options={{ title: 'Page Data' }} />
    </Stack.Navigator>
  );
};
