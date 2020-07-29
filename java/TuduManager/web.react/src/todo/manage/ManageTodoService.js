import { createHttp } from '../../Http';
import { HttpStatusCode } from '../../HttpStatusCode';

export function createManageTodoService(http = createHttp()){
    let self = {};

    self.search = async (text) => {
        const url = '/api/todos?searchText=' + text;
        const response = await http.get(url);
        if(response.statusCode  === HttpStatusCode.internalServerError){
            return  {
                statusCode: HttpStatusCode.internalServerError
            };
        }

        return {
            statusCode: HttpStatusCode.ok,
            todos: response.body
        }
    }

    self.delete = async (todoId) => {
        const url = '/api/todos/' + todoId;
        const response = await http.delete(url);
        if(response.statusCode === HttpStatusCode.internalServerError){
            return {statusCode: response.statusCode};
        }
        if(response.statusCode === HttpStatusCode.notFound){
            return {statusCode: response.statusCode};
        }
        if(response.statusCode === HttpStatusCode.ok){
            return {statusCode: response.statusCode};
        }
    }

    return self;
}
