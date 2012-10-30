class CreateRefVideoGenres < ActiveRecord::Migration
  def change
    create_table :ref_video_genres do |t|
      t.string :name
      t.timestamps
    end
  end
end
