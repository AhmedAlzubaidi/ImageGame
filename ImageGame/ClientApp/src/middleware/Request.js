export class Request {
    static baseURL = 'api/v1/game';

    static async getGames() {
        const response = await fetch(this.baseURL);
        const data = await response.json();
        return data;
    }

    static async getGamesById(gameID) {
        const response = await fetch(this.baseURL + '/' + gameID);
        const data = await response.json();
        return data;
    }
}
