import React, { Component } from 'react';
import { Request } from '../middleware/Request';

export class Play extends Component {
    static displayName = Play.name;

    constructor(props) {
        super(props);

        this.state = { 
            game: {},
            gameID: props.match.params.id,
            currentImage: 0,
            loading: true
        };

        this.pickDelay = 500;
        this.maxPicks = 10;
        this.picks = 0;
    }

    async populateGames() {
        const data = await Request.getGamesById(this.state.gameID);
        this.setState({ game: data, loading: false });
    }

    componentDidMount() {
        this.populateGames();
        setTimeout(this.pickRandomImage.bind(this), this.pickDelay);
    }

    pickRandomImage() {
        const length = this.state.game.images.length;
        const index = Math.floor(Math.random() * length); // maybe make sure it isn't equal to currentImage
        this.setState({
            currentImage: index
        });
        this.picks++;

        if(this.picks != this.maxPicks) {
            setTimeout(this.pickRandomImage.bind(this), this.pickDelay);
        }
    }

    renderGame() {
        return (
            <div className="col-sm-4 offset-sm-4 card">
                <img className="mt-3 card-img-top" src={this.state.game.images[this.state.currentImage].url} alt="Game image"></img>
                <div className="card-body">
                    <h5 className="card-title">{this.state.game.images[this.state.currentImage].key}</h5>
                </div>
            </div>
        );
    }

    render () {
        let game = this.state.loading
        ? <p><em>Loading...</em></p>
        : this.renderGame(this.state.games);

        return (
            <div className="row">
                {game}
            </div>
        );
    }
}