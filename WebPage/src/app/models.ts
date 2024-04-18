type nullableString = string | null | undefined;

export interface Book {
  id: number;
  title: string;
  genre: string;
  author: string;
  imageUrl: string;
  isFavorite: boolean;
}

export interface Signup {
  email: nullableString;
  firstName: nullableString;
  lastName: nullableString;
  password: nullableString;
}
