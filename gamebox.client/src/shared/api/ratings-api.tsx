import { get } from "../fetch-wrapper";

export function getRecentlyRated() {
    return get(`https://localhost:7281/ratings?projection=recent`)
}