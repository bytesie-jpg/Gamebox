import { get } from "../fetch-wrapper";
import { Rating } from "../types/rating";

export function getRecentlyRated(): Promise<Array<Rating>> {
    return get(`ratings?projection=recent`).then((resp: Response) => {
        if (resp.ok) {
            return resp.json().then((json) => {
                return json as Rating[];
            }) 
        } else return [];
    })
}