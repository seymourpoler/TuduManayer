import { ConnectionFactory } from "../../../src/infra/database/ConnectionFactory";

export class DataBase{
    constructor(private readonly connectionFactory: ConnectionFactory){}

    public async clear(): Promise<void>{
        const connection = this.connectionFactory.create();
        await connection.query("DELETE FROM public.Todos");
        await connection.end();
    }
}