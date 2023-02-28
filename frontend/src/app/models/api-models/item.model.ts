import { List } from "./list.model";

export interface Item{
    toDoItemId: string | null | undefined;
    name: string;
    description: string | null | undefined;
    notes: string | null | undefined;
    createdDate: Date | null | undefined;
    dueDate: Date;
    status: number | null | undefined;
    toDoListId: string;
}