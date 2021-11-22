package com.michal.zadanie6_mm;

import android.os.Build;

import androidx.annotation.RequiresApi;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;
import java.util.UUID;

import lombok.Getter;

public class TaskStorage {
    private static final TaskStorage taskStorage = new TaskStorage();


    private final List<Task> tasks;
    private static TaskStorage instance;

    public  static  TaskStorage getInstance(){
        return taskStorage;
    }

    private TaskStorage()
    {
        tasks = new ArrayList<>();
        for(int i=1; i<=100; i++) {
            Task task = new Task();
            task.setName("Zadanie #" + i);
            task.setDone(i % 3 == 0);
            tasks.add(task);
        }
    }


    public Task getTask(UUID id) {
        for(Task a: tasks)
        {
            if(a.getId().equals(id))
            {
                return a;
            }
        }
        return null;
    }

    public List<Task> getTasks() {
        return tasks;
    }
}
