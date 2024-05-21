<?php

use App\Http\Controllers\API\BookController;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;

Route::apiResource('/books', BookController::class);

Route::post('/books/{book}/rent',[BookController::class,'rent']);