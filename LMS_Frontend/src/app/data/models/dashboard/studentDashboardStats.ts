import { IRecentIssuesBook } from "./recentIssuesBook";

export interface IStudentDashboardStats {
    totalReview: number,
    wishlistedBook: number,
    borrowedBook: number,
    returnedBook: number,
    recentIssuedBooks: IRecentIssuesBook[]
}   