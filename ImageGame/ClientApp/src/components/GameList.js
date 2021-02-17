import React, { Component } from 'react';
import { Request } from '../middleware/Request';

export class GameList extends Component {
    static displayName = GameList.name;

    constructor(props) {
        super(props);
        this.state = { 
            games: [],
            loading: true
        };
    }

    async populateGames() {
        const data = await Request.getGames();
        this.setState({ games: data, loading: false });
    }

    componentDidMount() {
        this.populateGames();
        console.log(this.state.games);
    }

    static renderGames(games) {
        return (
            <div className="row">
                {games.map(game =>
                    <div className="col-sm-4 card">
                        <a href={"http://localhost:4264/games/" + game.id + "/play"}>
                            <img className="mt-3 card-img-top" src="https://cdn.streamelements.com/uploads/48b128a2-719b-43ff-97fb-aaba95d3c227.gif" alt="Game image"></img>
                        </a>
                        <div className="card-body">
                            <h5 className="card-title">{game.name}</h5>
                        </div>
                    </div>
                )}
            </div>
        )
    }
    render() {
        let gameList = this.state.loading
        ? <p><em>Loading...</em></p>
        : GameList.renderGames(this.state.games);

        if(!this.state.loading) {
            console.log(this.state.games);
        }

        return (
            <div>
                {gameList}
            </div>
        );
    }
}
