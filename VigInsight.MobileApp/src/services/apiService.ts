import { MachineModel, OrganizationModel, RoleModel, UserModel, UserSession } from '../types/models';
import { httpRequest } from './http';

type LoginResponse = {
  token?: string;
  Token?: string;
  username?: string;
  Username?: string;
  roleName?: string;
  RoleName?: string;
  role?: string;
  Role?: string;
  userId?: number;
  UserId?: number;
  roleId?: number;
  RoleId?: number;
  organizationId?: number;
  OrganizationId?: number;
  organizationName?: string;
  OrganizationName?: string;
};

const pick = <T>(obj: Record<string, unknown>, ...keys: string[]): T | undefined => {
  for (const key of keys) {
    if (obj[key] !== undefined) return obj[key] as T;
  }
  return undefined;
};

export async function login(username: string, password: string): Promise<UserSession> {
  const response = await httpRequest<LoginResponse>('/api/Login', {
    method: 'POST',
    body: JSON.stringify({ username, password })
  });

  const raw = response as Record<string, unknown>;
  const token = pick<string>(raw, 'token', 'Token') || '';
  const roleName = pick<string>(raw, 'roleName', 'RoleName', 'role', 'Role') || 'User';

  return {
    token,
    userId: pick<number>(raw, 'userId', 'UserId') || 0,
    username: pick<string>(raw, 'username', 'Username') || username,
    roleId: pick<number>(raw, 'roleId', 'RoleId') || 0,
    roleName,
    organizationId: pick<number>(raw, 'organizationId', 'OrganizationId') || 0,
    organizationName: pick<string>(raw, 'organizationName', 'OrganizationName')
  };
}

export const getUsers = (userId: number, role: string) =>
  httpRequest<UserModel[]>('/api/User', undefined, { userId, role });

export const getRoles = () => httpRequest<RoleModel[]>('/api/Role');

export const getOrganizations = (userId: number, role: string) =>
  httpRequest<OrganizationModel[]>('/api/Organization', undefined, { userId, role });

export const getAllOrganizations = () => httpRequest<OrganizationModel[]>('/api/Organization');

export const getMachines = (userId: number, role: string) =>
  httpRequest<MachineModel[]>('/api/Machine', undefined, { userId, role });

export const getMachinesByOrganization = (organizationId: number) =>
  httpRequest<MachineModel[]>(`/api/Machine/ByOrganization/${organizationId}`);

export const createUser = (payload: { user: Partial<UserModel>; organizationId: number }) =>
  httpRequest('/api/User', { method: 'POST', body: JSON.stringify(payload) });

export const updateUser = (id: number, payload: UserModel) =>
  httpRequest(`/api/User/${id}`, { method: 'PUT', body: JSON.stringify(payload) });

export const deleteUser = (id: number) =>
  httpRequest(`/api/User/${id}`, { method: 'DELETE' });

export const createOrganization = (payload: Partial<OrganizationModel>) =>
  httpRequest('/api/Organization', { method: 'POST', body: JSON.stringify(payload) });

export const updateOrganization = (id: number, payload: OrganizationModel) =>
  httpRequest(`/api/Organization/${id}`, { method: 'PUT', body: JSON.stringify(payload) });

export const deleteOrganization = (id: number) =>
  httpRequest(`/api/Organization/${id}`, { method: 'DELETE' });

export const createMachine = (payload: { machine: Partial<MachineModel>; organizationId: number }) =>
  httpRequest('/api/Machine', { method: 'POST', body: JSON.stringify(payload) });

export const updateMachine = (id: number, payload: { machine: MachineModel; organizationId: number }) =>
  httpRequest(`/api/Machine/${id}`, { method: 'PUT', body: JSON.stringify(payload) });

export const deleteMachine = (id: number) =>
  httpRequest(`/api/Machine/${id}`, { method: 'DELETE' });

export const getPageData = (pageId: number) => httpRequest<Record<string, unknown>>(`/api/PageData/${pageId}`);
