import Search from '@mui/icons-material/Search';
import HomeOutlined from '@mui/icons-material/HomeOutlined';
import StarBorderOutlined from '@mui/icons-material/StarBorderOutlined';
import GroupOutlined from '@mui/icons-material/GroupOutlined';
import ShuffleOutlined from '@mui/icons-material/ShuffleOutlined';
import { IconButton } from '../buttons/IconButton';
import styles from './Header.module.scss';
import { TextField } from '@mui/material';

export const Header = () => {
    return (
        <div className={styles.headerLayout }>
            <header className={styles.mainTitleHeader}><h1>GAMEBOX</h1></header>
            <div className={styles.iconButtonsGroup}>
                <IconButton icon={<HomeOutlined sx={{ width: 35, height: 35 }} />} value={'Home'} onButtonPress={(e) => { console.log(e) }} />
                <IconButton icon={<StarBorderOutlined sx={{ width: 35, height: 35 }} />} value={'Create Review'} onButtonPress={(e) => { console.log(e) }} />
                <IconButton icon={<GroupOutlined sx={{ width: 35, height: 35 }}  />} value={'Group'} onButtonPress={(e) => { console.log(e) }} />
                <IconButton icon={<ShuffleOutlined sx={{ width: 35, height: 35 }} />} value={'Random Game'} onButtonPress={(e) => { console.log(e) }} />
            </div>
            <div className={styles.searchLayout}>
                <TextField inputProps={{ style: { fontSize: 18, color: 'white' } }} InputLabelProps={{ style: { fontSize: 18 } }} size="small" className={styles.searchField} variant="outlined" fullWidth slotProps={{
                    input: {
                        startAdornment: (
                            <Search sx = {{ width: 35, height: 35, color: 'white' }} />
                        ),
                    },
                }}/>
            </div>
        </div>
    )
}