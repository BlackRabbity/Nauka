package com.michal.sensorapp;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.Fragment;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.content.Context;
import android.content.Intent;
import android.hardware.Sensor;
import android.hardware.SensorManager;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;
import static com.michal.sensorapp.SensorDetailsActivity.EXTRA_SENSOR;
import java.util.Arrays;
import java.util.List;

public class SensorActivity extends AppCompatActivity {

    private SensorManager sensorManager;
    private List<Sensor> sensorList;
    RecyclerView recyclerView = null;
    private SensorAdapter adapter;
    private static final String SENSOR_TAG = "SENSOR_TAG";
    private static final String KEY_CURRENT_VISIBILITY = "Current_Visibility";
    private boolean widac;
    private final List<Integer> favourSensors = Arrays.asList(Sensor.TYPE_LIGHT, Sensor.TYPE_PRESSURE);

    @Override
    public void onSaveInstanceState(Bundle outState) {
        super.onSaveInstanceState(outState);
        outState.putBoolean(KEY_CURRENT_VISIBILITY, widac);
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.sensors_menu, menu);
        MenuItem subtitleItem = menu.findItem(R.id.sensor_count);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(@NonNull MenuItem item) {
        String napis = getString(R.string.sensors_count, sensorList.size());
        widac = !widac;
        if (!widac) {
            napis = null;
        }
        getSupportActionBar().setSubtitle(napis);
        return true;
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.sensor_activity);
        recyclerView = findViewById(R.id.sensor_recycler_view);
        recyclerView.setLayoutManager(new LinearLayoutManager(this));
        sensorManager = (SensorManager) getSystemService(Context.SENSOR_SERVICE);
        sensorList = sensorManager.getSensorList(Sensor.TYPE_ALL);

        for (int i = 0; i < sensorList.size(); i++) {
            Log.d(SENSOR_TAG, "Sensor name:" + sensorList.get(i).getName());
            Log.d(SENSOR_TAG, "Sensor vendor:" + sensorList.get(i).getVendor());
            Log.d(SENSOR_TAG, "Sensor max range:" + sensorList.get(i).getMaximumRange());
        }

        if (adapter == null) {
            adapter = new SensorAdapter(sensorList);
            recyclerView.setAdapter(adapter);
        } else {
            adapter.notifyDataSetChanged();
        }

    }
    private class SensorHolder extends RecyclerView.ViewHolder {
        private Sensor sensor;
        private final TextView nameTextView;
        private final ImageView iconImageView;

        public SensorHolder(LayoutInflater inflater, ViewGroup parent) {
            super(inflater.inflate(R.layout.sensor_list_item, parent, false));

            nameTextView = itemView.findViewById(R.id.item_sensor_name);
            iconImageView = itemView.findViewById(R.id.imageView);

        }

        public void bind(Sensor sensor) {
            nameTextView.setText(sensor.getName());
            iconImageView.setImageResource(R.drawable.ic_sensor_icon);
            View itemContainer = itemView.findViewById(R.id.list_item_sensor);
            if (favourSensors.contains(sensor.getType())) {
                    itemContainer.setBackgroundColor(getResources().getColor(R.color.item_background));
                    itemContainer.setOnClickListener(v -> {
                    Intent intent = new Intent(SensorActivity.this, SensorDetailsActivity.class);
                    intent.putExtra(EXTRA_SENSOR, sensor.getType());
                    startActivity(intent);
                });
            }


        }
    }



        private class SensorAdapter extends RecyclerView.Adapter<SensorHolder> {
            private List<Sensor> sensors;

            public SensorAdapter(List<Sensor> sensors) {
                this.sensors = sensors;
            }


            @NonNull
            @Override
            public SensorHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
                LayoutInflater layoutInflater = LayoutInflater.from(parent.getContext());
                return new SensorHolder(layoutInflater, parent);

            }

            @Override
            public void onBindViewHolder(@NonNull SensorHolder holder, int position) {
                Sensor sensor = sensors.get(position);
                holder.bind(sensor);
            }

            public int getItemCount() {
                return sensors.size();
            }


        }


    }