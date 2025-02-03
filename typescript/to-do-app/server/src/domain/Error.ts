export class Error {
    public fieldId: string;
    public message: string;
    constructor(
        private readonly theFieldId: string,
        private readonly theMessage: string) {
        this.fieldId = theFieldId;
        this.message = theMessage;
    }
}