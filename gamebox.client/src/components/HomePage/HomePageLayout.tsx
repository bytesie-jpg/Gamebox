import { RightHandLayout } from "../RightHandLayout"
import { SectionHeader } from "../../shared/components/SectionHeader"
import { Divider } from "../../shared/components/Divider"
import { getRecentlyRated } from "../../shared/api/ratings-api"
import { useEffect } from "react"

export const HomePageLayout = () => {
    useEffect(() => {
        getRecentlyRated().then((resp) => {
            console.log(resp);
        });
    })
    return (
        <RightHandLayout
            main={
                <div>
                    <SectionHeader title={'Explore recently rated games'} />

                    <Divider/>
                </div>
            }
            side={<div>side test</div>}
        />
    )

}