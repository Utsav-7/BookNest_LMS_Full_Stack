export interface ILoginResponse {
    success: boolean;
    message: string;
    data: {
        token: string;
        user: {
            id: string;
            email: string;
            role: string;
            firstName: string,
            lastName: string,
            profileImageUrl: string
        };
    };
}