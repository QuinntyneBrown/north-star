export interface ChildProfile {
  id: string;
  firstName: string;
  grade: number;
  birthYear?: number | null;
  interests: string;
  loginHandle: string;
}

export interface CreateChildRequest {
  firstName: string;
  grade: number;
  birthYear?: number | null;
  interests: string;
  loginHandle: string;
  pin: string;
}
