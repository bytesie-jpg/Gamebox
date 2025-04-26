import { Game } from "./game";
import { User } from "./user";

export type Rating = {
    id: string,
    user: User,
    game: Game,
    difficulty: number,
    innovation: number,
    gameplay: number,
    story: number,
    visuals: number,
    replayability: number,
    avgRatingUnweighted: number,
    avgRatingWeighted: number,
    gifted: boolean;
    review: string;
    lastUpdated: Date;
}