import { API_BASE_URL } from '../config/env';

let authToken = '';

export const setAuthToken = (token: string) => {
  authToken = token;
};

const toQueryString = (query?: Record<string, string | number | undefined>) => {
  if (!query) return '';
  const params = Object.entries(query)
    .filter(([, value]) => value !== undefined && value !== null)
    .map(([key, value]) => `${encodeURIComponent(key)}=${encodeURIComponent(String(value))}`)
    .join('&');

  return params ? `?${params}` : '';
};

export async function httpRequest<T>(
  path: string,
  options?: RequestInit,
  query?: Record<string, string | number | undefined>
): Promise<T> {
  const response = await fetch(`${API_BASE_URL}${path}${toQueryString(query)}`, {
    ...options,
    headers: {
      'Content-Type': 'application/json',
      ...(authToken ? { Authorization: `Bearer ${authToken}` } : {}),
      ...(options?.headers || {})
    }
  });

  if (!response.ok) {
    const errorText = await response.text();
    throw new Error(errorText || `API error: ${response.status}`);
  }

  if (response.status === 204) {
    return null as T;
  }

  return (await response.json()) as T;
}
