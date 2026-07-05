export type UserSession = {
  token: string;
  userId: number;
  username: string;
  roleId: number;
  roleName: string;
  organizationId: number;
  organizationName?: string;
};

export type RoleModel = {
  roleId: number;
  roleName: string;
  isActive?: boolean;
};

export type OrganizationModel = {
  organizationId: number;
  organizationName: string;
  organizationDescription?: string;
  isActive: boolean;
  createdBy?: string;
  createdOn?: string;
  modifiedBy?: string;
  modifiedOn?: string;
};

export type UserModel = {
  userId: number;
  username: string;
  password?: string;
  roleId: number;
  roleName?: string;
  isActive: boolean;
  createdBy?: string;
  createdOn?: string;
  modifiedBy?: string;
  modifiedOn?: string;
  organizationId: number;
  organizationName?: string;
};

export type MachineModel = {
  machineId: number;
  machineName: string;
  machineDescription?: string;
  isActive: boolean;
  createdBy?: string;
  createdOn?: string;
  modifiedBy?: string;
  modifiedOn?: string;
  organizationId: number;
  organizationName?: string;
  performance?: string;
  alert?: string;
  isOnline?: boolean;
  hourlyProduction?: number;
  powerConsumption?: number;
};
