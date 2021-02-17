export class Request {
    async games() {
        const response = await fetch('game');
        const data = await response.json();
        return data;
    }

    async gameById(gameID) {
        const response = await fetch('game/' + gameID);
        const data = await response.json();
        return data;
    }
}
