package com.michal.sensorapp;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Context;
import android.hardware.Sensor;
import android.hardware.SensorEvent;
import android.hardware.SensorEventListener;
import android.hardware.SensorManager;
import android.os.Bundle;
import android.view.View;
import android.widget.TextView;


public class SensorDetailsActivity extends AppCompatActivity implements SensorEventListener {
    public static final String EXTRA_SENSOR = "EXTRA_SENSOR_TYPE";

    private SensorManager sensorManager;
    private Sensor sensorLight;
    private TextView sensorLightTextView;
    private TextView sensorNameTextView;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_sensor_details);

        sensorLightTextView = findViewById(R.id.sensor_value);
        sensorNameTextView = findViewById(R.id.sensor_name);
        int sensorType = getIntent().getIntExtra(EXTRA_SENSOR, Sensor.TYPE_LIGHT);
        sensorManager = (SensorManager) getSystemService(Context.SENSOR_SERVICE);
        sensorLight = sensorManager.getDefaultSensor(sensorType);
        if (sensorLight == null) {
            sensorNameTextView.setText(R.string.missing_sensor);
        } else {
            sensorNameTextView.setText(sensorLight.getName());
        }
    }

    @Override
    protected  void onStart()
    {
        super.onStart();
        if(sensorLight!=null) {
            sensorManager.registerListener(this, sensorLight, SensorManager.SENSOR_DELAY_NORMAL);
        }
    }

    @Override
    protected void onStop()
    {
        super.onStop();
        sensorManager.unregisterListener(this);
    }

    @Override
    public void onSensorChanged(SensorEvent sensorEvent) {
        int sensorType = sensorEvent.sensor.getType();
        float currentValue = sensorEvent.values[0];
        switch (sensorType) {
            case Sensor.TYPE_LIGHT:
                sensorLightTextView.setText(getResources().getString(R.string.light_sensor_label,currentValue));
            case Sensor.TYPE_PRESSURE:
                sensorLightTextView.setText(getResources().getString(R.string.pressure_sensor_label,currentValue));
                break;

        }

    }
    @Override
    public void onAccuracyChanged(Sensor sensor, int accuracy) {

    }
}