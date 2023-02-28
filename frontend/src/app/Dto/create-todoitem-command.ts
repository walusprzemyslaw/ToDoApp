export interface CreateTodoitemCommand {
    name: string;
    notes: string;
    description: string;
    dueDate: string;
    toDoListId: string;
}
