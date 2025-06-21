export interface IBorrowResponse {
    borrowRequestId: number,
    userId: number,
    title: string,
    firstName: string,
    lastName: string,
    email: string,
    status: string,
    requestDate: string,
    approvedBy: string,
    approvedDate: string,
    dueDate: string,
    returnDate: string;
}