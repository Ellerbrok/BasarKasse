import { Button, CardActions, CardContent, CardMedia, Typography } from "@mui/material"
import Card from "@mui/material/Card"
import { Link, useParams } from "react-router"
import { useActivities } from "../../../lib/hooks/useActivities";

export default function ActivityDetail() {
  const {id} = useParams();
  const { activity, isLoadingActivity } = useActivities(id);

  if (isLoadingActivity) return <Typography>Loading...</Typography>
  if (!activity) return <Typography>Activity not found...</Typography>

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
        <Button component={Link} to={`/editActivity/${activity.id}`} color="primary">Edit</Button>
        <Button component={Link} to="/activities" color="inherit">Cancel</Button>
      </CardActions>
    </Card>
  )
}
