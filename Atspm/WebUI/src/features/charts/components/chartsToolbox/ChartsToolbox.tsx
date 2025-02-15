import { useChartsStore } from '@/stores/charts'
import {
  Box,
  Button,
  Checkbox,
  Divider,
  FormControlLabel,
  Paper,
  Toolbar,
  Typography,
  useTheme,
} from '@mui/material'
import React from 'react'
import IndividualChartControls from './IndividualChartControls'

interface GeneralChartsControllerProps {
  chartRefs: React.RefObject<HTMLDivElement>[]
  chartData: any
  toggleConfigLabel: string
  toggleConfig: () => void
}

export default function ChartsToolbox({
  chartRefs,
  chartData,
  toggleConfigLabel,
  toggleConfig,
}: GeneralChartsControllerProps) {
  const theme = useTheme()

  const { syncZoom, setSyncZoom } = useChartsStore()
  return (
    <Paper
      sx={{
        position: 'sticky',
        top: -5,
        marginTop: '-50px',
        zIndex: 1000,
        backgroundColor: '#D3D3D3',
        width: 'fit-content',
        mx: 'auto',
      }}
    >
      <Toolbar variant="dense" sx={{ px: 1 }}>
        <Box sx={{ display: 'flex', alignItems: 'center', width: '100%' }}>
          <FormControlLabel
            control={
              <Checkbox
                checked={syncZoom}
                onChange={() => setSyncZoom(!syncZoom)}
                name="showPermissivePhases"
                color="default"
                size="small"
              />
            }
            label={
              <Typography
                fontWeight={400}
                fontSize={'.8rem'}
                sx={{ textTransform: 'none' }}
              >
                Sync Zoom
              </Typography>
            }
            sx={{ flexGrow: 1 }}
          />
          <Button
            onClick={toggleConfig}
            sx={{
              marginRight: 1,
              mx: '2px',
              color: theme.palette.text.primary,
              textTransform: 'none',
            }}
          >
            <Typography
              fontWeight={400}
              fontSize={'.8rem'}
              sx={{ textTransform: 'none' }}
            >
              View {toggleConfigLabel}
            </Typography>
          </Button>
          <Divider orientation="vertical" flexItem sx={{ mx: 1 }} />
          <IndividualChartControls
            charts={chartData.data.charts}
            chartRefs={chartRefs}
            isDisabled={toggleConfigLabel === 'Charts'}
          />
        </Box>
      </Toolbar>
    </Paper>
  )
}
