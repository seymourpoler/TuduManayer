export class Error {
    public readonly fieldId: string;
    public readonly message: string;

    constructor( fieldId: string, message: string) {
        this.fieldId = fieldId;
        this.message = message;
    }
}