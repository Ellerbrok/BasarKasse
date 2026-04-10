import { Group, PointOfSale } from '@mui/icons-material'
import { Box, Button, Paper, Typography } from '@mui/material'
import { Link } from 'react-router'

export default function HomePage() {
  return (
    <Paper
      sx={{
        color: "white",
        display: "flex",
        flexDirection: "column",
        gap: 6,
        alignItems: "center",
        alignContent: "center",
        justifyContent: "center",
        height: "100vh",
        backgroundImage: 'linear-gradient(135deg, #182873 0%, #218aae 60%, #20a7ac 90%)'
      }}
    >
        <Box sx={{ 
          display: 'flex', 
          alignItems: 'center', 
          alignContent: 'center', 
          color: "white",
          gap: 3 }}
        >
          <PointOfSale sx={{height: 110, width: 110}} />
          <Typography variant="h1">
            BasarKasse
          </Typography>
        </Box>
        <Typography variant="h2">
          Welcome to BasarKasse
        </Typography>
        <Button
          component={Link}
          to="/activities"
          size="large"
          variant="contained"
          sx={{ height: 80, fontSize: "1.5rem", borderRadius: 5 }}
        >
          Go to activities
        </Button>
    </Paper>
  )
}
