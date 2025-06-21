export interface IUser {
    id?: number;
    email: string;
    role: string;
    firstName: string;
    lastName: string;
    profileImageUrl?: string;
    mobileNo: string;
    isActive: boolean;
    passwordHash?: string;
}  