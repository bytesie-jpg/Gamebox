import { RightHandLayout } from "../RightHandLayout"
import { SectionHeader } from "../../shared/components/SectionHeader"
import { Divider } from "../../shared/components/Divider"

export const HomePageLayout = () => {
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