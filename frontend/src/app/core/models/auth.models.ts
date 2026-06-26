export interface AuthResponse {
  accessToken: string;
  email: string;
  displayName: string;
  role: string;
  familyId: string;
  childId?: string | null;
}

export interface LoginRequest {
  email: string;
  password: string;
}

export interface RegisterRequest {
  email: string;
  password: string;
  displayName: string;
  familyName: string;
}

export interface ChildLoginRequest {
  loginHandle: string;
  pin: string;
}

export interface CurrentUser {
  email: string;
  displayName: string;
  role: string;
  familyId: string;
  childId?: string | null;
}
