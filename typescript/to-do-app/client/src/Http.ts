export class Http {
  public async get(url: string): Promise<any> {
    const response = await fetch(url);
    return await response.json();
  }

  public async post(url: string, data: any): Promise<any> {
    return await fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(data),
        });
    }

    public async put(url: string, data: any): Promise<any> {
        return await fetch(url, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(data),
        });
    }

    public async delete(url: string): Promise<any> {
        return await fetch(url, {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json',
            },
        });
    }
}