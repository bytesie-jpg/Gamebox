import defaultImg from "../../../assets/TBDimg.png"
import styles from "./SingleGameRating.module.scss"
import { Star } from "@mui/icons-material";
interface SingleGameRatingProps {
    overallRating: number;
    title: string;
    logoUrl: string;
}

export const SingleGameRating = ({ overallRating, title, logoUrl }: SingleGameRatingProps) => {
    const renderImage = () => {
        if (logoUrl == "EMPTY") {
            return (
                <img src={defaultImg} />
            )
        } else return (<div>No Img</div>)
    }

    return (
        <div className={styles.ratingContainer}>
            <div className={styles.imageAndStar}>
                <img src={defaultImg}/>
                <div className={styles.ratingNumberContainer}>
                    <Star sx={{ width: 20, height: 20 }} />
                    <span className={styles.ratingNumber}>{overallRating.toFixed(2)}</span>
                </div>
            </div>
            <span className={styles.title}>{title.toUpperCase()}</span>
        </div>
    )
}