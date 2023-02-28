import { Item } from "./item.model";

export interface List{
    toDoListId: string | null | undefined,
    name: string;
    visibility: boolean | null | undefined;
    hiddenFinishedItems: boolean  | null | undefined;
    items: Item[] | null | undefined;
    userId: string | null | undefined;
    username: string  | null | undefined;
}