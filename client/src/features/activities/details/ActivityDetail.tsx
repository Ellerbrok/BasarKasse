import { Button, CardActions, CardContent, CardMedia, Typography } from "@mui/material"
import Card from "@mui/material/Card"

type Props = {
    activity: Activity
    cancelSelectActivity: () => void
}

export default function ActivityDetail({ activity, cancelSelectActivity }: Props) {
  return (
    <Card>
      <CardMedia 
        component="img"
        src={ `/images/categoryImages/culture.jpg` }
      />
      <CardContent>
        <Typography variant="h5">{activity.name}</Typography>
        <Typography variant="subtitle1" fontWeight="light">{activity.date}</Typography>
        <Typography variant="body1">{activity.id}</Typography>
      </CardContent>
      <CardActions>
        <Button color="primary">Edit</Button>
        <Button color="inherit" onClick={cancelSelectActivity} >Cancel</Button>
      </CardActions>
    </Card>
  )
}
