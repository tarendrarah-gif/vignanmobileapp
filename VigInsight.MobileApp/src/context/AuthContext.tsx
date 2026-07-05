import AsyncStorage from '@react-native-async-storage/async-storage';
import React, { createContext, PropsWithChildren, useContext, useEffect, useMemo, useState } from 'react';
import { login as loginApi } from '../services/apiService';
import { setAuthToken } from '../services/http';
import { UserSession } from '../types/models';

type AuthContextValue = {
  session: UserSession | null;
  isLoading: boolean;
  signIn: (username: string, password: string) => Promise<void>;
  signOut: () => Promise<void>;
};

const SESSION_KEY = 'viginsight.mobile.session';

const AuthContext = createContext<AuthContextValue>({
  session: null,
  isLoading: true,
  signIn: async () => {},
  signOut: async () => {}
});

export const AuthProvider = ({ children }: PropsWithChildren) => {
  const [session, setSession] = useState<UserSession | null>(null);
  const [isLoading, setIsLoading] = useState(true);

  useEffect(() => {
    (async () => {
      const rawSession = await AsyncStorage.getItem(SESSION_KEY);
      if (rawSession) {
        const saved = JSON.parse(rawSession) as UserSession;
        setSession(saved);
        setAuthToken(saved.token);
      }
      setIsLoading(false);
    })();
  }, []);

  const signIn = async (username: string, password: string) => {
    const newSession = await loginApi(username, password);
    setSession(newSession);
    setAuthToken(newSession.token);
    await AsyncStorage.setItem(SESSION_KEY, JSON.stringify(newSession));
  };

  const signOut = async () => {
    setSession(null);
    setAuthToken('');
    await AsyncStorage.removeItem(SESSION_KEY);
  };

  const value = useMemo(
    () => ({
      session,
      isLoading,
      signIn,
      signOut
    }),
    [session, isLoading]
  );

  return <AuthContext.Provider value={value}>{children}</AuthContext.Provider>;
};

export const useAuth = () => useContext(AuthContext);
