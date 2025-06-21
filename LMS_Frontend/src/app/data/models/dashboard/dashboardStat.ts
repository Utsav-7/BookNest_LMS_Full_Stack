import { IRecentIssuesBook } from "./recentIssuesBook";

export interface IDashboardStat {
    books: number,
    borrowedBooks: number,
    returnedBook: number,
    students: number,
    librarians: number,
    genres: number,
    reviews: number,
    totalCopies: number,
    recentIssuedBooks: IRecentIssuesBook[]
}