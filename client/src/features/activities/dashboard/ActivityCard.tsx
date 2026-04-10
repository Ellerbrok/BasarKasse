import { Button, Card, CardActions, CardContent, Chip, Typography, Box } from "@mui/material"
import { useActivities } from "../../../lib/hooks/useActivities";
import { Link } from "react-router"

type Props = {
    activity: Activity
}

export default function ActivityCard({ activity }: Props) {
    const {deleteActivity} = useActivities();

  return (
    <Card>
        <CardContent>
            <Typography variant="h5">{activity.name}</Typography>
            <Typography sx={{color: 'text.secondary', mb: 1}}>{activity.date}</Typography>
        </CardContent>
        <CardActions sx={{display: 'flex', justifyContent: 'space-between', pb : 2}}>
            <Chip label={activity.id}  variant="outlined"/>
            <Box display="flex" gap={2}>
                <Button
                    component={Link} 
                    to={`/activities/${activity.id}`}
                    size="medium" 
                    variant="contained">
                    View
                </Button>
                <Button 
                    size="medium" 
                    variant="contained" 
                    color="error" 
                    onClick={() => deleteActivity.mutate(activity.id)}
                    loading={deleteActivity.isPending}>
                    Delete
                </Button>
            </Box>
        </CardActions>
    </Card>
  )
}
