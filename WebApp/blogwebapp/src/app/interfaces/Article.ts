export interface Article {
  id: number;
  title: string;
  content: string;
  author: string;
  publishedDate: Date;
  tags?: string[];
  isPublished: boolean;
}
