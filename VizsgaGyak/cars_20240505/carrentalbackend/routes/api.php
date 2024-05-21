<?php

use App\Http\Controllers\API\CarController;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;

Route::apiResource('/cars',CarController::class);

Route::post('/cars/{car}/rent',[CarController::class,'rent']);