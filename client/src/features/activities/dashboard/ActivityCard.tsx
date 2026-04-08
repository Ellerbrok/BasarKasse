import { Button, Card, CardActions, CardContent, Chip, Typography, Box } from "@mui/material"
import { useActivities } from "../../../lib/hooks/useActivities";

type Props = {
    activity: Activity
    selectActivity: (id: string) => void
}

export default function ActivityCard({ activity, selectActivity }: Props) {
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
                <Button size="medium" variant="contained" onClick={() => selectActivity(activity.id)}>View</Button>
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
