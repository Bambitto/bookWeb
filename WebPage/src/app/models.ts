type nullableString = string | null | undefined;

export interface Book {
  id: string;
  title: string;
  author: string;
  genre: string;
  genreId: string;
  score: DoubleRange;
  CreatedDate: Date;
  UpdatedDate: Date;
  Reviews: Review[];
}

export interface Signup {
  email: nullableString;
  firstName: nullableString;
  lastName: nullableString;
  password: nullableString;
}

export interface Review {
  bookId: string;
  comment: string;
  id: string;
  score: number;
  userId: string;
  user: any | null;
}
