import { Pool } from "pg";
import { Configuration } from './Configuration';

export class ConnectionFactory{
    public constructor(private readonly configuration : Configuration){}

    public create(): Pool{
        return new Pool({
            host: this.configuration.host, 
            database: this.configuration.database, 
            user: this.configuration.username, 
            password: this.configuration.password,
            port: this.configuration.port,
            idleTimeoutMillis: 30000,
        });
    }
}