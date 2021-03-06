import {HttpStatusCode} from "../../HttpStatusCode";
import {createHttp} from "../../Http";

export function EditTodoService(http){
    let self = this;
    const url = '/api/todos';

    self.find = async function(todoId){
        const response = await http.get(url + '/' + todoId);
        if(response.statusCode === HttpStatusCode.ok){
            return {
                statusCode: HttpStatusCode.ok,
                todo: response.body
            };
        }
        return  { statusCode: response.statusCode };
    }

    self.update = async function(todo) {
        const response = await http.put(url, todo);
        if(response.statusCode === HttpStatusCode.badRequest){
            return {
                statusCode: response.statusCode,
                errors: response.body
            }
        }

        return {
            statusCode: response.statusCode
        }
    }
}

export function createEditTodoService() {
    const http = createHttp();
    return new EditTodoService(http);
}