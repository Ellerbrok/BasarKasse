import { AccessTime } from "@mui/icons-material";
import { Button, Card, CardContent, Chip, Typography, Box, CardHeader, Avatar, Divider } from "@mui/material"
import { Link } from "react-router"
import { formatDate } from "../../../lib/util/util";

type Props = {
    activity: Activity
}

export default function ActivityCard({ activity }: Props) {
    const isHost = false;
    const isGoing = false;
    const label = isHost ? 'You are hosting this activity' : 'You are going to this activity';
    const isCancelled = false;
    const color = isHost ? 'secondary' : isGoing ? 'warning' : 'default';

    return (
        <Card elevation={3}>
            <Box display="flex" alignItems="center" justifyContent="space-between">
                <CardHeader
                    avatar={<Avatar sx={{ height: 80, width: 80 }} />}
                    title={activity.name}
                    slotProps={{
                        title: {
                            sx: {
                                fontWeight: 'bold',
                                fontSize: 20,
                            },
                        },
                    }}
                />
                <Box display="flex" flexDirection="column" gap={2} mr={2}>
                    {(isHost || isGoing) && <Chip label={label} color={color} />}
                    {isCancelled && <Chip label="Cancelled" color="error" />}
                </Box>
            </Box>

            <Divider sx={{ mb: 3 }} />

            <CardContent sx={{ p: 0 }}>
                <Box display="flex" alignItems="center" px={2} mb={2}>
                    <Box display="flex" flexGrow={0} alignItems="center">
                        <AccessTime sx={{ mr: 1 }} />
                        <Typography variant="body2" noWrap>
                            {formatDate(activity.date)}
                        </Typography>
                    </Box>
                </Box>
                <Divider />
                <Box display="flex" gap={2} sx={{ backgroundColor: 'grey.200', py: 3, pl: 3 }}>
                    Attendees
                </Box>
            </CardContent>
            <CardContent sx={{ pb: 2 }}>
                <Button
                    component={Link}
                    to={`/activities/${activity.id}`}
                    size="medium"
                    variant="contained"
                    sx={{ display: "flex", justifySelf: "self-end" }}
                >
                    View
                </Button>
            </CardContent>
        </Card>
    )
}
